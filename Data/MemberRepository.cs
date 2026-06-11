using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class MemberRepository(AppDbContext context) : ImemberRepository
    {
        public async Task<Member> GetMemberByIdAsync(string id)
        {
           return await context.Members.FindAsync(id);
        }

        public async Task<IReadOnlyList<Member>> GetMembersAsync()
        {
            return await context.Members.Include(x=>x.Photos).ToListAsync();
        }

        public async Task<IReadOnlyList<Photo>> GetPhotosForMemberAsync(string memberId)
        {
            return await context.Members.Where(x => x.ID==memberId).SelectMany(x=>x.Photos).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync()>0;
        }

        public void update(Member member)
        {
            context.Entry(member).State=EntityState.Modified;
        }

    }
}